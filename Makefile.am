SUBDIRS = sources gtkmozembed doc sample

# Only newer versions of pkgconfig support stuff being in datadir. People
# using distros that have not backported the patch or have not upgraded
# pkgconfig might need to add something to their pkgconfig path.
pkgconfigdir = $(datadir)/pkgconfig
pkgconfig_DATA = gecko-sharp-2.0.pc

EXTRA_DIST = gecko-sharp-2.0.pc LICENSE.LGPL LICENSE.MPL gecko-sharp.pub gecko-sharp.snk

DISTCLEANFILES = gecko-sharp-2.0.pc
