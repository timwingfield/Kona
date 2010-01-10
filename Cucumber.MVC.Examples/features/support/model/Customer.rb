class Customer < ActiveRecord::Base
   set_primary_key :UserName
   has_many :Order

  def self.find_or_create(username)
    customer = self.find_by_UserName username

    if customer.nil?
      customer = Customer.new
      customer.UserName = username
      customer.Email = Faker::Internet.email
      customer.First = Faker::Name.first_name
      customer.LanguageCode = 'en'
    end
    customer
  end
end
