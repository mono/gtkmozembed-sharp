prefix=/usr
BROWSER=../../monodoc/browser/browser.exe
ASSEMBLER=../../monodoc/browser/assembler.exe
GENERATOR=../../monodoc/generator/generator.exe
UPDATER=../../monodoc/generator/updater.exe

all: gtkmozembed-sharp-docs.zip gtkmozembed-sharp-docs.tree

gtkmozembed-sharp-docs.zip gtkmozembed-sharp-docs.tree: en/*/*.xml
	mono $(ASSEMBLER) --ecma en -o gtkmozembed-sharp-docs

install: gtkmozembed-sharp-docs.zip gtkmozembed-sharp-docs.tree 
	install -m 644 gtkmozembed-sharp-docs.zip gtkmozembed-sharp-docs.tree `monodoc --get-sourcesdir`
	install -m 644 gtkmozembed-sharp-docs.source `monodoc --get-sourcesdir`

clean:
	rm *.tree
	rm *zip
