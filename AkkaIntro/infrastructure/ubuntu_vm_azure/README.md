# Ubuntu VM for Demo

## Prep

* Install the azure cli: `choco install azure-cli`
* Login `az login`
* Set your subscription: `az account set --subscription "the_subscription_guid"`
* Set any variables in `demo.tfvars`

## Planning

* Run `terraform plan --var-file="demo.tfvars"`

## Applying

* Run `terraform apply --var-file="demo.tfvars"`
