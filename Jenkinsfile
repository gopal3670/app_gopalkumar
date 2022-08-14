pipeline {
    agent any
	
	environment {
		sonarhome = tool name: 'sonar_scanner_dotnet'
		username = 'admin'
		appname = 'SampleApp'
	}
    
    stages {
        stage('Code Checkout'){
            steps {
                git branch: 'main', url: 'https://github.com/gopal3670/app_gopalkumar.git'
            }
        }
        stage('Nuget Restore'){
            steps {
                bat 'dotnet restore'
            }
        }
        stage('Clean'){
            steps {
                bat 'dotnet clean'
            }
        }
		stage('Start SonarQube Analysis'){
            steps {
				echo 'Starting sonarqube analysis'
				withSonarQubeEnv('Sonar'){
					bat "dotnet ${sonarhome}\\SonarScanner.MSBuild.dll begin /k:\"nagp-assignment\" /d:sonar.verbose=true -d:sonar.cs.xunit.reportsPath='test-project/TestResults/nagpMultiPipelineTestFileReport.xml'" 
				}
            }
        }
        stage('Build'){
            steps {
                bat 'dotnet build'
            }
        }
        stage('Test'){
            steps {
                bat 'dotnet test --logger:trx;LogFileName=appgopalkumartest.xml'
            }
        }
		stage('Stop SonarQube Analysis'){
            steps {
				echo 'Stopping sonarqube analysis'
				withSonarQubeEnv('Sonar'){
					bat "dotnet ${sonarHome}\\SonarScanner.MSBuild.dll end" 
				}
            }
        }
		stage('Release Artifact'){
            steps {
				echo 'Release Artifact Step'
				bat "dotnet publish -c Release -o ${appname}/app/${username}" 
            }
        }
    }
}
