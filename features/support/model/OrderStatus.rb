class OrderStatus < ActiveRecord::Base
  has_many :Order
  set_primary_key :OrderStatusID
  set_table_name 'OrderStatus'

  def self.find_or_create
    status = self.find_by_OrderStatusID 1
    if(status.nil?)
      status = OrderStatus.new
      status.OrderStatusID = 1
      status.Description = 'New'
      status.save
    end
    status
  end
end
