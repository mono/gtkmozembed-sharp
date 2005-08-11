if ENABLE_MONODOC
docdir = `pkg-config monodoc --variable=sourcesdir`
doc_DATA = gecko-sharp-docs.zip gecko-sharp-docs.tree gecko-sharp-docs.source
endif

noinst_DATA = $(TARGETS)

ASSEMBLER = mdassemble 
UPDATER = $(MONODOC) --update

gecko-sharp-docs.zip gecko-sharp-docs.tree: $(srcdir)/en/*/*.xml $(srcdir)/en/*.xml
	$(ASSEMBLER) --ecma $(srcdir)/en -o gecko-sharp-docs

update:
		$(UPDATER) ../gtkmozembed-sharp/gecko-sharp.dll -o ./en -f

CLEANFILES = gecko-sharp-docs.zip gecko-sharp-docs.tree

EXTRA_DIST = gecko-sharp-docs.source gecko-sharp-docs.tree gecko-sharp-docs.zip

dist-hook:
	mkdir -p $(distdir)/en
	cp $(srcdir)/en/*.xml $(distdir)/en/
	mkdir -p $(distdir)/en/Gecko
	cp $(srcdir)/en/Gecko/*.xml $(distdir)/en/Gecko/

