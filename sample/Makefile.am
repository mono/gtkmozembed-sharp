EXTRA_DIST = GtkMozApp.cs

all: GtkMozApp.exe

GtkMozApp.exe: GtkMozApp.cs MozWindow.cs
	$(MCS) --unsafe \
	-L @top_srcdir@/gtkmozembed \
	-r gtkgecko-sharp.dll \
	-L $(GTKSHARP_PREFIX)/lib \
	-r glib-sharp.dll -r gtk-sharp.dll -r gdk-sharp.dll \
	-r System.Drawing \
	-o GtkMozApp.exe GtkMozApp.cs MozWindow.cs

test: GtkMozApp.exe
	cp @top_srcdir@/gtkmozembed/gtkmozembed-sharp.dll .
	$(MONO) GtkMozApp.exe

clean:
	rm -f GtkMozApp.exe
	rm -f *.dll
