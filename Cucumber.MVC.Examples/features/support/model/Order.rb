class Order < ActiveRecord::Base
  set_primary_key :OrderID
  has_many :OrderItem
  has_one :OrderStatus, :primary_key => "OrderStatusID", :foreign_key => "OrderStatusID"
  belongs_to :Customer, :primary_key => "UserName", :foreign_key => "UserName"

  def self.find_or_create()
    order = Order.new
    order.ModifiedOn = DateTime.now
    order.CreatedOn = DateTime.now

    order.OrderStatusID = OrderStatus.find_or_create
    order.OrderID = Guid.new.to_s
    order.Customer = Customer.find_or_create Faker::Internet.user_name
    order
  end
end
