all: gtkmozembed-sharp.dll
 
gtkmozembed-sharp.dll: @srcdir@/generated/*.cs
	$(MCS) --unsafe --target library -L $(GTKSHARP_PREFIX)/lib \
	-r glib-sharp.dll -r gtk-sharp.dll -r gdk-sharp.dll \
	--recurse '@srcdir@/*.cs' -o gtkmozembed-sharp.dll
 
clean:
	rm -f *.dll
 
maintainerclean:
	rm -rf generated
 
install: all
	cp gtkmozembed-sharp.dll $(DESTDIR)@prefix@/lib
 
EXTRA_DIST = @srcdir@/generated/*.cs
