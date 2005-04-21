EXTRA_DIST = GtkMozApp.cs MozWindow.cs webshot.in WebThumbnailer.cs
CLEANFILES = GtkMozApp.exe WebThumbnailer.exe webshot

bin_SCRIPTS = webshot

exedir = $(libdir)/gecko-sharp
exe_DATA = WebThumbnailer.exe

webshot: webshot.in
	sed -e 's^\@libdir\@^$(libdir)^g' < $(srcdir)/webshot.in > webshot.tmp \
        && mv webshot.tmp webshot

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
