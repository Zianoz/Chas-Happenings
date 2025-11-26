// Dynamic Calendar Generator
(function() {
    'use strict';

    function generateCalendar() {
        const calendarSection = document.getElementById('calendar');
        if (!calendarSection) return;

        const now = new Date();
        const currentYear = now.getFullYear();
        const currentMonth = now.getMonth(); // 0-11
        const currentDay = now.getDate();

        // Month names
        const monthNames = [
            'January', 'February', 'March', 'April', 'May', 'June',
            'July', 'August', 'September', 'October', 'November', 'December'
        ];

        // Update calendar title
        const calendarTitle = calendarSection.querySelector('h2');
        if (calendarTitle) {
            calendarTitle.textContent = `${monthNames[currentMonth]} ${currentYear}`;
        }

        // Get first day of month (0 = Sunday, 1 = Monday, etc.)
        const firstDay = new Date(currentYear, currentMonth, 1).getDay();
        // Get number of days in month
        const daysInMonth = new Date(currentYear, currentMonth + 1, 0).getDate();

        // Get calendar grid
        const calendarGrid = calendarSection.querySelector('.calendar-grid');
        if (!calendarGrid) return;

        // Clear existing calendar (except headers)
        const headers = calendarGrid.querySelectorAll('.calendar-cell.header');
        calendarGrid.innerHTML = '';
        
        // Re-add headers
        const weekdays = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'];
        weekdays.forEach((day, index) => {
            const headerCell = document.createElement('div');
            headerCell.className = 'calendar-cell header';
            if (index >= 5) { // Sat and Sun
                headerCell.classList.add('weekend');
            }
            headerCell.textContent = day;
            calendarGrid.appendChild(headerCell);
        });

        // Adjust firstDay for Monday start (0 = Monday, 6 = Sunday)
        const adjustedFirstDay = firstDay === 0 ? 6 : firstDay - 1;

        // Add empty cells before first day
        for (let i = 0; i < adjustedFirstDay; i++) {
            const emptyCell = document.createElement('div');
            emptyCell.className = 'calendar-cell';
            calendarGrid.appendChild(emptyCell);
        }

        // Add day cells
        for (let day = 1; day <= daysInMonth; day++) {
            const dayCell = document.createElement('div');
            dayCell.className = 'calendar-cell';
            dayCell.textContent = day;

            // Calculate day of week (0 = Monday, 6 = Sunday)
            const dayOfWeek = (adjustedFirstDay + day - 1) % 7;

            // Mark weekends
            if (dayOfWeek >= 5) { // Saturday or Sunday
                dayCell.classList.add('weekend');
            }

            // Mark today
            if (day === currentDay) {
                dayCell.classList.add('today');
            }

            // Add click event to fetch events for this day
            dayCell.addEventListener('click', function() {
                if (this.textContent) {
                    const selectedDate = new Date(currentYear, currentMonth, day);
                    console.log('Selected date:', selectedDate.toLocaleDateString());
                    // You can add functionality here to show events for this day
                }
            });

            calendarGrid.appendChild(dayCell);
        }

        // Fill remaining cells to complete the grid
        const totalCells = adjustedFirstDay + daysInMonth;
        const remainingCells = totalCells % 7;
        if (remainingCells > 0) {
            for (let i = 0; i < (7 - remainingCells); i++) {
                const emptyCell = document.createElement('div');
                emptyCell.className = 'calendar-cell';
                calendarGrid.appendChild(emptyCell);
            }
        }

        // Fetch and mark events
        fetchAndMarkEvents(currentYear, currentMonth);
    }

    // Fetch events from API and mark them on calendar
    async function fetchAndMarkEvents(year, month) {
        try {
            // Create date range for the month
            const startDate = new Date(year, month, 1);
            const endDate = new Date(year, month + 1, 0);

            // Format dates for API (ISO format)
            const startDateStr = startDate.toISOString();
            const endDateStr = endDate.toISOString();

            // Fetch events from API
            const response = await fetch(`/api/Event/getbydate?startDate=${startDateStr}&endDate=${endDateStr}`);
            
            if (response.ok) {
                const events = await response.json();
                
                // Mark days with events
                events.forEach(event => {
                    const eventDate = new Date(event.eventDate);
                    const eventDay = eventDate.getDate();
                    
                    // Only mark if event is in current month
                    if (eventDate.getMonth() === month) {
                        const calendarCells = document.querySelectorAll('.calendar-cell:not(.header)');
                        calendarCells.forEach(cell => {
                            if (cell.textContent == eventDay) {
                                cell.classList.add('has-event');
                            }
                        });
                    }
                });
            }
        } catch (error) {
            console.error('Error fetching events:', error);
        }
    }

    // Initialize calendar when DOM is ready
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', generateCalendar);
    } else {
        generateCalendar();
    }

    // Optional: Add navigation buttons for previous/next month
    window.calendarAPI = {
        refresh: generateCalendar
    };
})();
