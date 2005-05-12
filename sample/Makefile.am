EXTRA_DIST = GtkMozApp.cs MozWindow.cs webshot.in WebThumbnailer.cs
CLEANFILES = GtkMozApp.exe WebThumbnailer.exe

bin_SCRIPTS = webshot

exedir = $(prefix)/lib/gecko-sharp-2.0
exe_DATA = WebThumbnailer.exe

all: GtkMozApp.exe WebThumbnailer.exe

GtkMozApp.exe: $(srcdir)/GtkMozApp.cs $(srcdir)/MozWindow.cs
	$(MCS) -unsafe \
	-lib:@top_builddir@/gtkmozembed \
	-r:gecko-sharp.dll \
	-lib:$(GTKSHARP_PREFIX)/lib \
	-pkg:gtk-sharp-2.0 \
	-r:System.Drawing \
	-out:GtkMozApp.exe $(srcdir)/GtkMozApp.cs $(srcdir)/MozWindow.cs

WebThumbnailer.exe: $(srcdir)/WebThumbnailer.cs
	$(MCS) 	-lib:@top_builddir@/gtkmozembed \
	-r:gecko-sharp.dll \
	-pkg:gtk-sharp-2.0 $(srcdir)/WebThumbnailer.cs \
	-out:WebThumbnailer.exe
