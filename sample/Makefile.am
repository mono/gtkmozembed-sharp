EXTRA_DIST = GtkMozApp.cs MozWindow.cs
CLEANFILES = GtkMozApp.exe WebThumbnailer.exe webshot

bin_SCRIPTS = webshot

exedir = $(libdir)/gecko-sharp
exe_DATA = WebThumbnailer.exe

webshot: webshot.in
	sed -e 's^\@libdir\@^$(libdir)^g' < $(srcdir)/webshot.in > webshot.tmp \
        && mv webshot.tmp webshot

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
