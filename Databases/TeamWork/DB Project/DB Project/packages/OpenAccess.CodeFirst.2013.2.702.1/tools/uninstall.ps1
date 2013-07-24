param($installPath, $toolsPath, $package, $project)

# This is the MSBuild targets file to add
$targetsFile = [System.IO.Path]::Combine($toolsPath, 'enhancer\OpenAccess.targets')

# Need to load MSBuild assembly if it's not loaded yet.
Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'

# Grab the loaded MSBuild project for the project
$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1

# Remove the property EnhancerAssembly
$msbuild.Xml.Properties | Where-Object {$_.Name.ToLowerInvariant() -eq "enhancerassembly" } | Foreach { 
    $_.Parent.RemoveChild( $_ ) 
}

# Remove imports to PostSharp.targets
$msbuild.Xml.Imports | Where-Object {$_.Project.ToLowerInvariant().EndsWith("openaccess.targets") } | Foreach { 
    $_.Parent.RemoveChild( $_ ) 
}

# Remove the error task
$beforeBuildTarget = $msbuild.Xml.Targets | Where {$_.Name -eq "BeforeBuild"} | Select-Object -First 1
if ($beforeBuildTarget-ne $null)
{
	$beforeBuildTarget.Tasks | Where-Object { $_.Condition.ToLowerInvariant().Contains('openaccess.targets') } | Foreach { 
        $_.Parent.RemoveChild( $_ ) 
    }

    if ($beforeBuildTarget.Tasks.Count -eq 0)
    {
        $beforeBuildTarget.Parent.RemoveChild($beforeBuildTarget)
    }
}

# Save the project
$project.Save()
