pipeline {
    agent any
	
	environment {
		username = 'gopalkumar'
		appname = 'DevOpsApp'
	}
    
    stages {
        stage('Code Checkout'){
            steps {
                git branch: 'develop', url: 'https://github.com/gopal3670/app_gopalkumar.git'
            }
        }
        stage('Nuget Restore'){
            steps {
                bat 'dotnet restore'
            }
        }
        stage('Code Build'){
            steps {
				bat 'dotnet clean'
                bat 'dotnet build'
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