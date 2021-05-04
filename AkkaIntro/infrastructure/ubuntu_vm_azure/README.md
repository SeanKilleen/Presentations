# Ubuntu VM for Demo

## Prep

* Install the azure cli: `choco install azure-cli`
* Install terraform: `choco install terraform`
* Login to Azure: `az login`
* Set your subscription: `az account set --subscription "the_subscription_guid"`
* Set any variables in `demo.tfvars`
* Run `terraform init` to initialize

## Planning

* Run `terraform plan --var-file="demo.tfvars"`

## Applying

* Run `terraform apply --var-file="demo.tfvars"`

## Get into the VM

* Get the public IP from Azure
* `ssh adminuser@public_ip`
* Enter the password

## Clone the Repo

* `git clone https://github.com/SeanKilleen/Presentations.git`

## Install .NET

<https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu>

* `wget https://packages.microsoft.com/config/ubuntu/20.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb`
* `sudo dpkg -i packages-microsoft-prod.deb`
* `sudo apt-get update`
* `sudo apt-get install -y apt-transport-https && sudo apt-get update && sudo apt-get install -y dotnet-sdk-5.0`

## Modify the settings

* `cd BlankSlate`
* `nano Program.cs`
* Set the public hostname to the public IP address
* Set the private hostname to the private IP address

## Build & Run

* `cd Presentations\AkkaIntro\code`
* `dotnet restore`
* `dotnet build`
* `cd BlankSlate`
* `dotnet run`

## Do it

* Add the Remote IP Address to the remoting demo
* Run the remoting demo

## Done?

* Run `terraform destroy --var-file="demo.tfvars"` to clean up the resources
