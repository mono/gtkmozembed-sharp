
INCLUDE_APIS = \
	$(GTKSHARP_PREFIX)/share/gapi/gdk-api.xml \
	$(GTKSHARP_PREFIX)/share/gapi/gtk-api.xml \
	$(GTKSHARP_PREFIX)/share/gapi/atk-api.xml
			
all: generated-stamp gtkmozembed-sharp.dll

generated-stamp: gtkmozembed-api.xml
	$(GTKSHARP_PREFIX)/bin/gapi-fixup.exe --api=gtkmozembed-api.xml --metadata=GtkMozEmbed.metadata && \
	 	$(GTKSHARP_PREFIX)/bin/gapi_codegen.exe --generate gtkmozembed-api.xml --include $(INCLUDE_APIS) --outdir=generated --customdir=. --assembly-name=gtkmozembed-sharp && touch generated-stamp
 
gtkmozembed-sharp.dll: generated-stamp
	$(MCS) --unsafe --target library -L $(GTKSHARP_PREFIX)/lib \
	-r glib-sharp.dll -r gtk-sharp.dll -r gdk-sharp.dll \
	--recurse '@srcdir@/*.cs' -o gtkmozembed-sharp.dll
 
clean:
	rm -f *.dll
	rm -f generated-stamp
	rm -f generated/*.cs
 
maintainerclean: clean
	rm -rf generated
 
install: all
	cp gtkmozembed-sharp.dll $(DESTDIR)@prefix@/lib
 
EXTRA_DIST = @srcdir@/generated/*.cs
