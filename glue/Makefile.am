lib_LTLIBRARIES = libgtkmozembedsharpglue.la

BASESOURCES = \
	newwindow.c		\
	#

libgtkmozembedsharpglue_la_LDFLAGS = -module -avoid-version

libgtkmozembedsharpglue_la_SOURCES = 	\
	$(BASESOURCES) 

libgtkmozembedsharpglue_la_LIBADD = $(BASE_DEPENDENCIES_LIBS) $(MOZ_LIBS)

INCLUDES = -I$(top_srcdir) $(BASE_DEPENDENCIES_CFLAGS) $(MOZ_CFLAGS)

CLEANFILES = lib*.a

