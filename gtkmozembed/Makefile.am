MCS=mcs
RAW_API=gtkgecko-api.raw
API=gtkgecko-api.xml
METADATA=gtkgecko.metadata

INCLUDE_APIS = \
	$(GTKSHARP_PREFIX)/share/gapi/gdk-api.xml \
	$(GTKSHARP_PREFIX)/share/gapi/gtk-api.xml \
	$(GTKSHARP_PREFIX)/share/gapi/atk-api.xml

sources = NewWindowOrphan_handler.cs \
	  NewWindow_delegate.cs      \
	  NewWindow_handler.cs

build_sources = $(addprefix $(srcdir)/, $(sources))

customs = Single.custom WebControl.custom

CLEANFILES = gecko-sharp.dll generated-stamp generated/*.cs $(API)
			
all: generated-stamp gecko-sharp.dll

$(API): $(srcdir)/$(RAW_API) $(srcdir)/$(METADATA)
	cp $(srcdir)/$(RAW_API) $(API)
	chmod u+w $(API)
	mono $(GTKSHARP_PREFIX)/bin/gapi-fixup.exe --api=$(srcdir)/$(API) --metadata=$(srcdir)/$(METADATA)

generated-stamp: $(API)
	 mono $(GTKSHARP_PREFIX)/bin/gapi_codegen.exe --generate $(srcdir)/$(API) --include $(INCLUDE_APIS) --outdir=generated --customdir=$(srcdir) --assembly-name=gecko-sharp && touch generated-stamp
 
gecko-sharp.dll: $(build_sources) generated-stamp
	$(MCS) --unsafe --target library -L $(GTKSHARP_PREFIX)/lib \
	-r glib-sharp.dll -r gtk-sharp.dll -r gdk-sharp.dll \
	$(build_sources) generated/*.cs -o gecko-sharp.dll
 
EXTRA_DIST = $(API) $(RAW_API) $(sources) $(customs) $(METADATA)
