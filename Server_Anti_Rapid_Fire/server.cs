package antiRapidFire 
{
	function serverCmdUseTool(%client,%t)
	{
		// This version is less glitchy but it uses schedules
		if(isEventPending(%client.antiRapidFireSched))
		{
			cancel(%client.antiRapidFireSched);
			%client.antiRapidFireSched = schedule(16,0,antiRapidFireCheck,%client,%t);
		}
		else
		{
			%client.antiRapidFireSched = schedule(16,0,antiRapidFireCheck,%client,%t);
			Parent::serverCmdUseTool(%client,%t);
		}
		
		//if(getSimTime()-%client.antiRapidFire >= 64 || !%client.antiRapidFire) 
		//{ 
		//	Parent::serverCmdUseTool(%client,%t); 
		//	%client.antiRapidFire=getsimtime();
		//}
	}
	
	function antiRapidFireCheck(%client,%t)
	{
		if(!isEventPending(%client.antiRapidFireSched))
			serverCmdUseTool(%client,%t);
	}
};
activatePackage("antiRapidFire");