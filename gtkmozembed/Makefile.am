MCS=mcs
RAW_API=gtkgecko-api.raw
API=gtkgecko-api.xml
METADATA=gtkgecko.metadata

INCLUDE_APIS = \
	$(GTKSHARP_PREFIX)/share/gapi/gdk-api.xml \
	$(GTKSHARP_PREFIX)/share/gapi/gtk-api.xml \
	$(GTKSHARP_PREFIX)/share/gapi/atk-api.xml
			
all: generated-stamp gtkgecko-sharp.dll

$(API): $(srcdir)/$(RAW_API) $(srcdir)/$(METADATA)
	cp $(srcdir)/$(RAW_API) $(API)
	chmod u+w $(API)
	mono $(GTKSHARP_PREFIX)/bin/gapi-fixup.exe --api=$(API) --metadata=$(srcdir)/$(METADATA)

generated-stamp: gtkgecko-api.xml
	 mono $(GTKSHARP_PREFIX)/bin/gapi_codegen.exe --generate gtkgecko-api.xml --include $(INCLUDE_APIS) --outdir=generated --customdir=. --assembly-name=gtkgecko-sharp && touch generated-stamp
 
gtkgecko-sharp.dll: generated-stamp
	$(MCS) --unsafe --target library -L $(GTKSHARP_PREFIX)/lib \
	-r glib-sharp.dll -r gtk-sharp.dll -r gdk-sharp.dll \
	--recurse '@srcdir@/*.cs' -o gtkgecko-sharp.dll
 
clean:
	rm -f *.dll
	rm -f generated-stamp
	rm -f generated/*.cs
 
maintainerclean: clean
	rm -rf generated
 
install: all
	cp gtkgecko-sharp.dll $(DESTDIR)@prefix@/lib
 
EXTRA_DIST = @srcdir@/generated/*.cs $(API) $(RAW_API)
