param($installPath, $toolsPath, $package, $project)

# This is the MSBuild targets file to add
$targetsFile = [System.IO.Path]::Combine($toolsPath, 'enhancer\OpenAccess.targets')

# Need to load MSBuild assembly if it's not loaded yet.
Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
# Grab the loaded MSBuild project for the project
$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1

# Make the path to the targets file relative.
$projectUri = new-object Uri('file://' + $project.FullName)
$targetUri = new-object Uri('file://' + $targetsFile)
$relativePath = $projectUri.MakeRelativeUri($targetUri).ToString().Replace([System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar)
$existsCondition = "Exists('" + $relativePath + "')"
#Add the enhancer item definition
$msbuild.Xml.AddProperty('EnhancerAssembly','enhancer.exe') | out-null

# Add the import 
$importElement = $msbuild.Xml.AddImport($relativePath) 
$importElement.Condition = $existsCondition

#hook the error task
#$propertyGroupHook = $msbuild.Xml.AddPropertyGroup()
#$propertyGroupHook.AddProperty("PrepareForBuildDependsOn", $targetErrorName + ';$(PrepareForBuildDependsOn)')

#hook the error task
$beforeBuildTask = $msbuild.Xml.Targets | Where {$_.Name -eq "BeforeBuild"} | Select-Object -First 1
if( $beforeBuildTask -eq $null)
{
    $beforeBuildTask = $msbuild.Xml.AddTarget("BeforeBuild")
}
$errorTask = $beforeBuildTask.AddTask("Error")
$errorTask.SetParameter("Text", 'Failed to import OpenAccess.targets from '+ $relativePath + '. Please make sure that the OpenAccess package is available and installed in that location. You can use the "Enable NuGet Package Restore" on your solution, or restore the package manually. You will need to reload the project in order for enhancing to occur. In order to run this on in a build environment you must ensure the build process restores the package before building the solution.')
$errorTask.Condition = "!" + $existsCondition

# Save the project
$project.Save()
