EXTRA_DIST = GtkMozApp.cs MozWindow.cs WebThumbnailer.cs
CLEANFILES = GtkMozApp.exe WebThumbnailer.exe

all: GtkMozApp.exe WebThumbnailer.exe

GtkMozApp.exe: $(srcdir)/GtkMozApp.cs $(srcdir)/MozWindow.cs
	$(MCS) -unsafe \
	-lib:@top_builddir@/gtkmozembed \
	-r:gecko-sharp.dll \
	-lib:$(GTKSHARP_PREFIX)/lib \
	-pkg:gtk-sharp-2.0 \
	-r:System.Drawing.dll \
	-out:GtkMozApp.exe $(srcdir)/GtkMozApp.cs $(srcdir)/MozWindow.cs

WebThumbnailer.exe: $(srcdir)/WebThumbnailer.cs
	$(MCS) 	-lib:@top_builddir@/gtkmozembed \
	-r:gecko-sharp.dll \
	-pkg:gtk-sharp-2.0 $(srcdir)/WebThumbnailer.cs \
	-out:WebThumbnailer.exe
