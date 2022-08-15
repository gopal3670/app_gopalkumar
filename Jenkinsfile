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
					bat "dotnet sonarscanner begin /k:'sonar-gopalkumar' /d:sonar.host.url='http://localhost:9000' /d:sonar.login='sqp_7c0b8d4830e37b4d3997cb5a9f2598b77aa5ee65'"
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
					bat "dotnet sonarscanner end /d:sonar.login='sqp_7c0b8d4830e37b4d3997cb5a9f2598b77aa5ee65'" 
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
