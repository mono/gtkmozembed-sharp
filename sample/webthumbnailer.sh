#!/bin/sh

if test -n "$MOZILLA_FIVE_HOME"; then
	MOZILLA_HOME=$MOZILLA_FIVE_HOME
elif [ -f @MOZILLA_HOME@/chrome/comm.jar ]; then
	MOZILLA_HOME=@MOZILLA_HOME@
elif [ $(which mozilla) ] && grep MOZILLA_FIVE_HOME= "$(which mozilla)" > /dev/null ; then
	MOZILLA_HOME=$(grep MOZILLA_FIVE_HOME= $(which mozilla) | cut -d '"' -f 2)
elif [ $(which firefox) ] && grep MOZILLA_FIVE_HOME= "$(which firefox)" > /dev/null ; then
	MOZILLA_HOME=$(grep MOZILLA_FIVE_HOME= $(which firefox) | cut -d '"' -f 2)
else
	echo "Cannot find mozilla installation directory. Please set MOZILLA_FIVE_HOME to your mozilla directory"
	exit 1
fi


if [ -n $LD_LIBRARY_PATH ]; then
	export LD_LIBRARY_PATH=$MOZILLA_HOME:$LD_LIBRARY_PATH
else
	export LD_LIBRARY_PATH=$MOZILLA_HOME
fi


export MOZILLA_FIVE_HOME=$MOZILLA_HOME

exec mono WebThumbnailer.exe $@
