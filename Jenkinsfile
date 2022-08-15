pipeline {
    agent any
	
	environment {
		def scannerHome = tool: 'sonar_scanner_dotnet'
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
				withSonarQubeEnv(Test_Sonar) {
				  bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll begin /k:\"sonar-gopalkumar\""
				  bat "dotnet build"
				  bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll end"
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
				withSonarQubeEnv('Test_Sonar'){
					bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll end" 
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
