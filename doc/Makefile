prefix=/usr
BROWSER=../../monodoc/browser/browser.exe
ASSEMBLER=../../monodoc/browser/assembler.exe
GENERATOR=../../monodoc/generator/generator.exe
UPDATER=../../monodoc/generator/updater.exe

all: gecko-sharp-docs.zip gecko-sharp-docs.tree

gecko-sharp-docs.zip gecko-sharp-docs.tree: en/*/*.xml
	mono $(ASSEMBLER) --ecma en -o gecko-sharp-docs

install: gecko-sharp-docs.zip gecko-sharp-docs.tree 
	install -m 644 gecko-sharp-docs.zip gecko-sharp-docs.tree `monodoc --get-sourcesdir`
	install -m 644 gecko-sharp-docs.source `monodoc --get-sourcesdir`

update: ../gtkmozembed/gecko-sharp.dll
	mono $(UPDATER) ../gtkmozembed/gecko-sharp.dll -o en/

clean:
	-rm *.tree
	-rm *zip
