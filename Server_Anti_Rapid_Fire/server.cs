deactivatePackage("antiRapidFire");
package antiRapidFire 
{
	function serverCmdUseTool(%client,%t)
	{
		// This version is less glitchy but it uses schedules
		
		if(%client.antiRapidFireCheck)
		{
			%client.antiRapidFireCheck = 0;
			Parent::serverCmdUseTool(%client,%t);
		}
		else
		{
			if(isEventPending(%client.antiRapidFireSched) && !%client.antiRapidFireCheck)
			{
				cancel(%client.antiRapidFireSched);
				%client.antiRapidFireSched = schedule(32,0,antiRapidFireCheck,%client,%t);
				%client.antiRapidFireCheck = 0;
			}
			else
			{
				cancel(%client.antiRapidFireSched);
				%client.antiRapidFireSched = schedule(32,0,antiRapidFireCheck,%client,%t);
				%client.antiRapidFireCheck = 0;
			}
		}
		
		//if(getSimTime()-%client.antiRapidFire >= 64 || !%client.antiRapidFire) 
		//{ 
		//	Parent::serverCmdUseTool(%client,%t); 
		//	%client.antiRapidFire=getsimtime();
		//}
	}
	
	function antiRapidFireCheck(%client,%t)
	{
		if(!isEventPending(%client.antiRapidFireSched) && !%client.antiRapidFireCheck)
		{
			%client.antiRapidFireCheck = 1;
			serverCmdUseTool(%client,%t);
		}
	}
};
activatePackage("antiRapidFire");