package antiRapidFire 
{
	function serverCmdUseTool(%client,%t) 
	{ 
		if(getSimTime()-%client.antiRapidFire >= 64 || !%client.antiRapidFire) 
		{ 
			Parent::serverCmdUseTool(%client,%t); 
			%client.antiRapidFire=getsimtime();
		}
	}
};
activatePackage("antiRapidFire");