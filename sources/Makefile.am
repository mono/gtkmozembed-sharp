if MAINTAINER_MODE
 
api:
	PERLLIB=$(GTKSHARP_PREFIX)/share/perl5  \
	PATH=$(GTKSHARP_PREFIX)/bin:$$PATH \
	gapi.pl gtkmozembed.sources @top_srcdir@/api

else

api:

endif

all: api

