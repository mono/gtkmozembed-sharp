MCS=mcs
RAW_API=gtkgecko-api.raw
API=gtkgecko-api.xml
METADATA=gtkgecko.metadata

ASSEMBLY_NAME= gecko-sharp
ASSEMBLY= $(ASSEMBLY_NAME).dll

INCLUDE_APIS = \
	$(GTKSHARP_PREFIX)/share/gapi-2.0/gdk-api.xml \
	$(GTKSHARP_PREFIX)/share/gapi-2.0/gtk-api.xml \
	$(GTKSHARP_PREFIX)/share/gapi-2.0/atk-api.xml

sources = NewWindowOrphan_handler.cs \
	  NewWindow_delegate.cs      \
	  NewWindow_handler.cs	     \
	  AssemblyInfo.cs

build_sources = $(addprefix $(srcdir)/, $(sources))

customs = Single.custom WebControl.custom

CLEANFILES = gecko-sharp.dll generated-stamp generated/*.cs $(API) gecko-sharp.snk

DISTCLEANFILES= AssemblyInfo.cs

noinst_DATA = gecko-sharp.dll
			
all: generated-stamp gecko-sharp.dll

$(API): $(srcdir)/$(RAW_API) $(srcdir)/$(METADATA)
	cp $(srcdir)/$(RAW_API) $(API)
	chmod u+w $(API)
	gapi2-fixup --api=$(srcdir)/$(API) --metadata=$(srcdir)/$(METADATA)

generated-stamp: $(API)
	 gapi2-codegen --generate $(srcdir)/$(API) --include $(INCLUDE_APIS) --outdir=generated --customdir=$(srcdir) --assembly-name=gecko-sharp && touch generated-stamp

gecko-sharp.snk: $(top_srcdir)/gecko-sharp.snk
	cp $(top_srcdir)/gecko-sharp.snk .

gecko-sharp.dll: $(build_sources) generated-stamp gecko-sharp.snk
	$(MCS) --unsafe --target library -L $(GTKSHARP_PREFIX)/lib \
	/pkg:gtk-sharp-2.0 \
	$(build_sources) generated/*.cs -o gecko-sharp.dll

install-data-local:
	echo "$(GACUTIL) /i $(ASSEMBLY) /f /package gecko-sharp /root $(DESTDIR)$(libdir)";  \
        $(GACUTIL) /i $(ASSEMBLY) /f /package gecko-sharp /root $(DESTDIR)$(libdir) || exit 1;
                                                                                
uninstall-local:
	echo "$(GACUTIL) /u $(ASSEMBLY_NAME) /package gecko-sharp /root $(DESTDIR)$(libdir)"; \
        $(GACUTIL) /u $(ASSEMBLY_NAME) /package gecko-sharp /root $(DESTDIR)$(libdir) || exit 1;
 
EXTRA_DIST = $(API) $(RAW_API) $(sources) $(customs) $(METADATA) AssemblyInfo.cs.in gecko-sharp.dll.config
