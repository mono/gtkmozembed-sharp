EXTRA_DIST = GtkMozApp.cs MozWindow.cs
CLEANFILES = GtkMozApp.exe

all: GtkMozApp.exe

GtkMozApp.exe: $(srcdir)/GtkMozApp.cs $(srcdir)/MozWindow.cs
	$(MCS) --unsafe \
	-L @top_builddir@/gtkmozembed \
	-r gecko-sharp.dll \
	-L $(GTKSHARP_PREFIX)/lib \
	-r glib-sharp.dll -r gtk-sharp.dll -r gdk-sharp.dll \
	-r System.Drawing \
	-o GtkMozApp.exe $(srcdir)/GtkMozApp.cs $(srcdir)/MozWindow.cs

clean:
	rm -f GtkMozApp.exe
