// Copyright 1998-2016 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.Collections.Generic;

public class UnrealMatch3Target : TargetRules
{
	public UnrealMatch3Target(TargetInfo Target)
	{
		Type = TargetType.Game;
	}

	//
	// TargetRules interface.
	//

	public override void SetupBinaries(
		TargetInfo Target,
		ref List<UEBuildBinaryConfiguration> OutBuildBinaryConfigurations,
		ref List<string> OutExtraModuleNames
		)
	{
		OutExtraModuleNames.AddRange( new string[] { "Match3" } );
	}

	public override List<UnrealTargetPlatform> GUBP_GetPlatforms_MonolithicOnly(UnrealTargetPlatform HostPlatform)
	{
		List<UnrealTargetPlatform> Platforms = null;

		switch (HostPlatform)
		{
			case UnrealTargetPlatform.Mac:
				Platforms = new List<UnrealTargetPlatform> { HostPlatform, UnrealTargetPlatform.IOS };
				break;

			case UnrealTargetPlatform.Win64:
				Platforms = new List<UnrealTargetPlatform> { HostPlatform, UnrealTargetPlatform.Android };
				break;

			default:
				Platforms = new List<UnrealTargetPlatform>();
				break;
		}

		return Platforms;
	}

	public override List<UnrealTargetPlatform> GUBP_GetBuildOnlyPlatforms_MonolithicOnly(UnrealTargetPlatform HostPlatform)
	{
		List<UnrealTargetPlatform> Platforms = null;

		switch (HostPlatform)
		{
			case UnrealTargetPlatform.Mac:
				Platforms = new List<UnrealTargetPlatform> { HostPlatform };
				break;

			case UnrealTargetPlatform.Win64:
				Platforms = new List<UnrealTargetPlatform> { HostPlatform, UnrealTargetPlatform.Win32 };
				break;

			default:
				Platforms = new List<UnrealTargetPlatform>();
				break;
		}

		return Platforms;
	}

	public override List<UnrealTargetConfiguration> GUBP_GetConfigs_MonolithicOnly(UnrealTargetPlatform HostPlatform, UnrealTargetPlatform Platform)
	{
		return new List<UnrealTargetConfiguration> { UnrealTargetConfiguration.Development, UnrealTargetConfiguration.Test };
	}

	public override List<GUBPFormalBuild> GUBP_GetConfigsForFormalBuilds_MonolithicOnly(UnrealTargetPlatform HostPlatform)
	{
		if (HostPlatform == UnrealTargetPlatform.Win64)
		{
			return new List<GUBPFormalBuild> 
			{
				new GUBPFormalBuild(UnrealTargetPlatform.Android, UnrealTargetConfiguration.Development),
				new GUBPFormalBuild(UnrealTargetPlatform.Android, UnrealTargetConfiguration.Test),
			};
		}
		else if (HostPlatform == UnrealTargetPlatform.Mac)
		{
			return new List<GUBPFormalBuild> 
			{
				new GUBPFormalBuild(UnrealTargetPlatform.IOS, UnrealTargetConfiguration.Development),
				new GUBPFormalBuild(UnrealTargetPlatform.IOS, UnrealTargetConfiguration.Test),
			};
		}
		else
		{
			return new List<GUBPFormalBuild>();
		}
	}
}
