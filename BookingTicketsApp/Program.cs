

using System;

//Added child classes for different means of handling booking

try
{
    LoyaltyBooking loyalty = new LoyaltyBooking(5);
    MonthlyBooking monthly = new MonthlyBooking(12);

    Console.WriteLine(loyalty.HandleBooking(200));
    Console.WriteLine(monthly.HandleBooking(200));

    loyalty.CurrentLoyalty = 300;
    
    Console.WriteLine(loyalty.HandleBooking(200));

} catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

abstract class BookingSystem
{
    // interface implementation as a property
    protected BookingPriceBehaviour? _priceBehaviour { get; set; }

    public BookingSystem()
    {
        _priceBehaviour = new BookingRegularPrice();
    }

    // METHODS
    // invocation of interface's method
    public decimal GetPrice(decimal initialPrice)
    {
        if (_priceBehaviour == null)
        {
            throw new InvalidOperationException("No price method set for booking.");
        }
        return _priceBehaviour.GetPrice(initialPrice);
    }

    protected void SetPriceBehaviour(BookingPriceBehaviour priceBehaviour)
    {
        _priceBehaviour = priceBehaviour;
    }

    protected abstract void SelectBookingPrice();

    public decimal HandleBooking(decimal price)
    {
        SelectBookingPrice();
        return GetPrice(price);
    }
}


class LoyaltyBooking : BookingSystem
{
    private int _currentLoyalty = 0;

    public int CurrentLoyalty { get { return _currentLoyalty; } set { _currentLoyalty = value; } }

    public LoyaltyBooking(int currentLoyalty)
    {
        _currentLoyalty = currentLoyalty;
    }


    // dynamically set booking price based on loyalty
    protected override void SelectBookingPrice()
    {
        BookingPriceBehaviour newPriceBehaviour;
        if(_currentLoyalty <= 0)
        {
            newPriceBehaviour = new BookingDoublePrice();
        }
        else if(_currentLoyalty > 0 && _currentLoyalty < 10)
        {
            newPriceBehaviour = new BookingRegularPrice();
        }
        else
        {
            newPriceBehaviour = new BookingQuarterDiscount();
        }

        SetPriceBehaviour(newPriceBehaviour);
    }
}

class MonthlyBooking : BookingSystem
{
    private int _currentMonth;

    public int CurrentMonth
    {
        get
        {
            return _currentMonth;
        }
        set
        {
            if (value > 0 && value < 13)
            {
                _currentMonth = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
    // dynamically set booking price based on current month
    protected override void SelectBookingPrice()
    {
        int december = 12;
        int june = 6;
        int july = 7;
        int october = 10;

        if (_currentMonth == december || _currentMonth == october)
        {
            _priceBehaviour = new BookingDoublePrice();
        }
        else if (_currentMonth == june || _currentMonth == july)
        {
            _priceBehaviour = new BookingHalfDiscount();
        }
        else
        {
            _priceBehaviour = new BookingRegularPrice();
        }
    }

    public MonthlyBooking(int currentMonth)
    {
        CurrentMonth = currentMonth;
    }
}

class HalfOffBookings : BookingSystem
{
    protected override void SelectBookingPrice()
    {
        _priceBehaviour = new BookingHalfDiscount();
    }

    // booking price is always half off
    public HalfOffBookings()
    {
        SelectBookingPrice();
    }
}

// BOOKING PRICE BEHAVIOURS
// interface of behaviour has multiple different implementations
interface BookingPriceBehaviour
{
    public decimal GetPrice(decimal initialPrice);
}

class BookingDoublePrice : BookingPriceBehaviour
{
    public decimal GetPrice(decimal initialPrice)
    {
        return initialPrice * 2;
    }
}

class BookingQuarterDiscount : BookingPriceBehaviour
{
    public decimal GetPrice(decimal initialPrice)
    {
        decimal discount = initialPrice * 0.25M;

        return initialPrice - discount;
    }
}

class BookingRegularPrice : BookingPriceBehaviour
{
    public decimal GetPrice(decimal initialPrice)
    {
        return initialPrice;
    }
}

class BookingHalfDiscount : BookingPriceBehaviour
{
    public decimal GetPrice(decimal initialPrice)
    {
        return initialPrice / 2;
    }
}