EXTRA_DIST = GtkMozApp.cs MozWindow.cs
CLEANFILES = GtkMozApp.exe

all: GtkMozApp.exe

GtkMozApp.exe: $(srcdir)/GtkMozApp.cs $(srcdir)/MozWindow.cs
	$(MCS) --unsafe \
	-L @top_builddir@/gtkmozembed \
	-r gecko-sharp.dll \
	-L $(GTKSHARP_PREFIX)/lib \
	/pkg:gtk-sharp \
	-r System.Drawing \
	-o GtkMozApp.exe $(srcdir)/GtkMozApp.cs $(srcdir)/MozWindow.cs

clean:
	rm -f GtkMozApp.exe
