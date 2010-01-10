class OrderItem < ActiveRecord::Base
  belongs_to :Order, :primary_key => "OrderID", :foreign_key => "OrderID"
  belongs_to :Product, :primary_key => "SKU", :foreign_key => "SKU"

  def self.create_item(order, product)
    item = OrderItem.new
    item.Order = order
    item.Product = Product.find_or_create(product)
    item.DateAdded = DateTime.now
    item.save
  end
end
