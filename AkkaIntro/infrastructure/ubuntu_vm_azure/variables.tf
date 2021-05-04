variable "prefix" {
  description = "The prefix which should be used for all resources in this example"
}

variable "location" {
  description = "The Azure Region in which all resources in this example should be created."
}

variable "admin_password" {
  sensitive   = true
  description = "The Password for the Azure VM. Only doing it this way for demo purposes."
}
