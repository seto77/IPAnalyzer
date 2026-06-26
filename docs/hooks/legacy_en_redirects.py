# 260625Cl: 旧英語マニュアル URL (/IPAnalyzer/en/<slug>/) を、static-i18n 移行後の
# 新ルート URL (/IPAnalyzer/<slug>/) へ逃がす post-build フック。
#
# 背景: 多言語化で mkdocs-static-i18n を導入し、default locale (en) をサイトルートへ出すようにした。
#   これにより英語ページの公開 URL が /IPAnalyzer/en/<slug>/ → /IPAnalyzer/<slug>/ へ移動する。
#   旧 /en/ URL は約3週間公開済みで、アプリ F1 ヘルプ・ブックマーク・検索エンジン索引が指している。
#
# なぜ mkdocs-redirects でなくフックか (ReciPro 実測で確定, 2026-06-22):
#   mkdocs-redirects の redirect target URL 算出は static-i18n の「再ホーム前」の名前空間に固定されており、
#   value `en/foo.md` は死 URL /en/foo/ に解決される (KEY==VALUE では url=./ の自己参照ループになる)。
#   → 英語の /en/→ルート 互換は mkdocs-redirects では張れない。将来の JA リネーム履歴 (/ja/旧→/ja/新) は
#     JA が /ja/ のままなので従来どおり mkdocs-redirects が担当する (mkdocs.yml の redirect_maps)。
#
# IPAnalyzer はページのリネーム履歴が無いので、現行ページの自動 alias (part 1) のみ。
# 過去にリネームが発生したら LEGACY_EN_RENAMES に {旧slug: 新slug} を足す (part 2)。

from pathlib import Path
import html
import os

import mkdocs.plugins

# 旧英語リネーム履歴: /IPAnalyzer/en/<旧slug>/ → /IPAnalyzer/<新slug>/ (新 slug はディレクトリ形・拡張子なし)。
# IPAnalyzer は en/ja split が初版でリネーム履歴が無いため、現状は空。
LEGACY_EN_RENAMES = {}

_STUB = (
    "<!doctype html>\n"
    '<html lang="en"><head><meta charset="utf-8">\n'
    '<meta http-equiv="refresh" content="0; url={url}">\n'
    '<link rel="canonical" href="{url}">\n'
    "<script>location.replace({url_js}+location.search+location.hash)</script>\n"
    '<title>Redirecting…</title></head><body>\n'
    '<a href="{url}">This page has moved. Redirecting…</a>\n'
    "</body></html>\n"
)


def _reserved_tops(config):
    """サイトルート直下で英語ページとして扱わない (=alias を張らない) トップ階層。
    i18n の languages から各 locale の出力ディレクトリ名を取り、assets/search を足して動的生成する。
    こうすると将来 de/fr/... を追加しても自動で予約され、それらに誤って /en/ alias を張らない。
    既定 locale (en) の名前も予約に含める (このフックが作る site/en/ alias を再ビルド時に再走査しないため)。"""
    locales = set()
    try:
        i18n = config["plugins"]["i18n"]
        for lang in i18n.config["languages"]:
            loc = lang.get("locale") if hasattr(lang, "get") else getattr(lang, "locale", None)
            if loc:
                locales.add(str(loc))
    except Exception:
        pass
    if not locales:
        # config から取れなかった場合のフォールバック (将来の波状展開を含む allow-list)。
        locales = {"en", "ja", "de", "fr", "es", "it", "ru", "zh-Hans", "zh-Hant", "ko", "pt"}
    return locales | {"assets", "search"}


@mkdocs.plugins.event_priority(-100)  # 他プラグイン (mkdocs-redirects 等) の on_post_build の後に走らせる
def on_post_build(config):
    site = Path(config.site_dir).resolve()
    en_dir = site / "en"
    reserved_top = _reserved_tops(config)

    def write_redirect(source_slug, target_slug):
        dest_dir = (en_dir / source_slug) if source_slug else en_dir
        target_dir = (site / target_slug) if target_slug else site
        target_index = target_dir / "index.html"
        if not target_index.exists():
            raise RuntimeError(f"legacy_en_redirects: target missing for /en/{source_slug}/ -> /{target_slug}/")

        dest_index = dest_dir / "index.html"
        rel = os.path.relpath(target_dir, dest_dir).replace("\\", "/")
        if rel == ".":
            # 自己参照 (無限リロード) を絶対に作らない。
            raise RuntimeError(f"legacy_en_redirects: self-loop for /en/{source_slug}/")
        url = (rel.rstrip("/") + "/") if rel != ".." else "../"
        dest_dir.mkdir(parents=True, exist_ok=True)
        dest_index.write_text(
            _STUB.format(url=html.escape(url), url_js=repr(url)), encoding="utf-8"
        )

    # (1) 現行の全英語ルートページ: /en/<slug>/ → /<slug>/ (将来追加ページも自動で互換 alias を持つ)。
    written = 0
    for index in sorted(site.rglob("index.html")):
        rel = index.relative_to(site)
        if rel.parts[0] in reserved_top:
            continue
        slug = "" if rel.parts == ("index.html",) else "/".join(rel.parts[:-1])
        write_redirect(slug, slug)
        written += 1

    # (2) 旧英語リネーム履歴: /en/<旧slug>/ → /<新slug>/ (IPAnalyzer は現状空)。
    for old_slug, new_slug in LEGACY_EN_RENAMES.items():
        write_redirect(old_slug, new_slug)

    mkdocs.plugins.log.info(
        "legacy_en_redirects: wrote %d current + %d legacy /en/ redirect stubs",
        written, len(LEGACY_EN_RENAMES),
    )
