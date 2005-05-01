if ENABLE_MONODOC
TARGETS = gecko-sharp-docs.zip gecko-sharp-docs.tree gecko-sharp-docs.source
DOCDIR = `$(MONODOC) --get-sourcesdir`

install-data-local:
	install -m 644 $(srcdir)/gecko-sharp-docs.source `monodoc --get-sourcesdir`
	install -m 644 $(srcdir)/gecko-sharp-docs.tree `monodoc --get-sourcesdir`
	install -m 644 $(srcdir)/gecko-sharp-docs.zip `monodoc --get-sourcesdir`
else
TARGETS = 
DOCDIR = $(datadir)
endif

noinst_DATA = $(TARGETS)

ASSEMBLER = $(MONODOC) --assemble
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

