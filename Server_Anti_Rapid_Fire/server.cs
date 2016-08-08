deactivatePackage("antiRapidFire");
package antiRapidFire 
{
	//UseTool (default)
	function serverCmdUseTool(%client,%t)
	{
		if(%client.antiRapidFireChecked)
		{
			%client.antiRapidFireChecked = 0;
			Parent::serverCmdUseTool(%client,%t);
		}
		else
		{
			cancel(%client.antiRapidFireSched);
			%client.antiRapidFireSched = schedule(32,0,antiRapidFireCheck,%client,%t);
			%client.antiRapidFireChecked = 0;
		}
	}
		
	//UnUseTool (1)
	function serverCmdUnUseTool(%client)
	{
		if(%client.antiRapidFireChecked)
		{
			%client.antiRapidFireChecked = 0;
			Parent::serverCmdUnUseTool(%client);
		}
		else
		{
			cancel(%client.antiRapidFireSched);
			%client.antiRapidFireSched = schedule(32,0,antiRapidFireCheck,%client,%t,1);
			%client.antiRapidFireChecked = 0;
		}
	}
	
	//UseInventory (2)
	function serverCmdUseInventory(%client,%t)
	{
		if(%client.antiRapidFireChecked)
		{
			%client.antiRapidFireChecked = 0;
			Parent::serverCmdUseInventory(%client,%t); // partially fixed a vulnerability
		}
		else
		{
			cancel(%client.antiRapidFireSched);
			%client.antiRapidFireSched = schedule(32,0,antiRapidFireCheck,%client,%t,2);
			%client.antiRapidFireChecked = 0;
		}
	}
	
	//UseSprayCan (3)
	function serverCmdUseSprayCan(%client,%t)
	{
		if(%client.antiRapidFireChecked)
		{
			%client.antiRapidFireChecked = 0;
			Parent::serverCmdUseSprayCan(%client,%t);
		}
		else
		{
			cancel(%client.antiRapidFireSched);
			%client.antiRapidFireSched = schedule(32,0,antiRapidFireCheck,%client,%t,3);
			%client.antiRapidFireChecked = 0;
		}
	}
	
	// antiRapidFireCheck ( Client, Tool, Type)
	// Types:
	// 0 Tools
	// 1 Tools (un-use)
	// 2 Inventory
	// 3 Paint
	function antiRapidFireCheck(%client,%t,%type)
	{
		if(!%client.antiRapidFireChecked)
		{
			%client.antiRapidFireChecked = 1;
			
			switch(%type)
			{
				case 1:
					serverCmdUnUseTool(%client);
				case 2:
					serverCmdUseInventory(%client,%t);
				case 3:
					serverCmdUseSprayCan(%client,%t);
				default:
					serverCmdUseTool(%client,%t);
			}
		}
	}
};
activatePackage("antiRapidFire");