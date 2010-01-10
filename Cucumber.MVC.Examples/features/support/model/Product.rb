class Product < ActiveRecord::Base
  has_many :OrderItem
  set_primary_key :SKU
                            
  def self.find_or_create(name)
    product = self.find_by_ProductName name 

    if product.nil?
      product = Product.new
      product.SKU = Faker::Lorem.words(1).to_s + rand(10).to_s
      product.ProductName = name
    end
    product
  end
end
