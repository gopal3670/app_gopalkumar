pipeline {
    agent any
	
	environment {
		scannerHome = tool name: 'sonar_scanner_dotnet'
		username = 'admin'
		appname = 'SampleApp'
	}
    
    stages {
        stage('Code Checkout'){
            steps {
                git branch: 'master', url: 'https://github.com/gopal3670/app_gopalkumar.git'
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
				withSonarQubeEnv('Test_Sonar') {
				  bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll begin /k:\"sonar-gopalkumar\""
				  bat "dotnet build"
				  bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll end"
				}
            }
        }
    }
}
