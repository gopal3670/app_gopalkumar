pipeline {
    agent any
	environment {
		sonarScannerDotnetHome = tool name: 'sonar_scanner_dotnet'
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
		stage('Start SonarQube Analysis'){
            steps {
				withSonarQubeEnv('Test_Sonar') {
				  bat "dotnet ${sonarScannerDotnetHome}\\SonarScanner.MSBuild.dll begin /k:\"sonar-gopalkumar\""
				}
            }
        }
		stage('Code Build'){
            steps {
				bat 'dotnet clean'
                bat 'dotnet build'
            }
        }
        stage('Test Case Execution'){
            steps {
                bat 'dotnet test --logger:trx;LogFileName=appgopalkumartest.xml'
            }
        }
		stage('Stop SonarQube Analysis'){
            steps {
				echo 'Stopping SonarQube Analysis'
				withSonarQubeEnv('Test_Sonar'){
					bat "dotnet ${sonarScannerDotnetHome}\\SonarScanner.MSBuild.dll end" 
				}
            }
        }
    }
}
