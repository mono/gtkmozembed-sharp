EXTRA_DIST = GtkMozApp.cs MozWindow.cs
CLEANFILES = GtkMozApp.exe

all: GtkMozApp.exe WebThumbnailer.exe

GtkMozApp.exe: $(srcdir)/GtkMozApp.cs $(srcdir)/MozWindow.cs
	$(MCS) --unsafe \
	-L @top_builddir@/gtkmozembed \
	-r gecko-sharp.dll \
	-L $(GTKSHARP_PREFIX)/lib \
	-pkg:gtk-sharp \
	-r System.Drawing \
	-o GtkMozApp.exe $(srcdir)/GtkMozApp.cs $(srcdir)/MozWindow.cs

WebThumbnailer.exe: $(srcdir)/WebThumbnailer.cs
	$(MCS) 	-L @top_builddir@/gtkmozembed \
	-r gecko-sharp.dll \
	-pkg:gtk-sharp $(srcdir)/WebThumbnailer.cs

clean:
	rm -f GtkMozApp.exe
