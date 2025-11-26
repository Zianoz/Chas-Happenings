async function onCalendarEventClick(eventId) {
    try {
        const response = await fetch(`/api/Event/getbyid/extradata/${eventId}`);

        if (!response.ok) {
            throw new Error("Failed to load event details");
        }

        const data = await response.json();

        const container = document.getElementById("dynamic-info");
        if (!container) return;

        const title = data.title || `Event #${eventId}`;
        const description = data.description || "";
        const presentation = data.presentation || "";
        const text1 = data.text1 || "";
        const text2 = data.text2 || "";
        const location = data.location || "";
        const type = data.type || "";

        const eventDateRaw = data.eventDate;
        let dateDisplay = "";
        if (eventDateRaw) {
            const d = new Date(eventDateRaw);
            dateDisplay = d.toLocaleDateString("sv-SE");
        }

        const startRaw = data.startTime;
        const endRaw = data.endTime;

        const startDisplay = startRaw ? startRaw.substring(0, 5) : "";
        const endDisplay = endRaw ? endRaw.substring(0, 5) : "";

        const tags = Array.isArray(data.tags) ? data.tags : [];
        const comments = Array.isArray(data.comments) ? data.comments : [];
        const tagNames = tags
            .map(t => t.name || t.title || t.tagName || "")
            .filter(x => x)
            .join(", ");

        container.innerHTML = `
            <h2>${title}</h2>

            <p><strong>Type:</strong> ${type}</p>
            <p><strong>Date:</strong> ${dateDisplay}</p>
            <p><strong>Time:</strong> ${startDisplay}${endDisplay ? " – " + endDisplay : ""}</p>
            ${location ? `<p><strong>Location:</strong> ${location}</p>` : ""}

            ${description ? `<p><strong>Description:</strong><br>${description}</p>` : ""}
            ${presentation ? `<p><strong>Presentation:</strong><br>${presentation}</p>` : ""}
            ${text1 ? `<p>${text1}</p>` : ""}
            ${text2 ? `<p>${text2}</p>` : ""}

            ${tagNames ? `<p><strong>Tags:</strong> ${tagNames}</p>` : ""}
            <p><strong>Comments:</strong> ${comments.length}</p>
        `;
    } catch (err) {
        console.error("Error loading event details:", err);

        const container = document.getElementById("dynamic-info");
        if (container) {
            container.innerHTML = `<p>Could not load event details for ID ${eventId}.</p>`;
        }
    }
}

function applyEventFilters() {
    const boxes = document.querySelectorAll(".filter-box");
    const activeTypes = [];

    boxes.forEach(box => {
        if (box.classList.contains("active")) {
            const classes = Array.from(box.classList);
            const filterClass = classes.find(c => c.startsWith("filter-") && c !== "filter-box");
            if (filterClass) {
                const typeName = filterClass.replace("filter-", "");
                activeTypes.push(typeName);
            }
        }
    });

    const pills = document.querySelectorAll(".event-pill");

    if (activeTypes.length === 0) {
        pills.forEach(p => {
            p.style.display = "none";
        });
    } else {
        pills.forEach(p => {
            const classes = Array.from(p.classList);
            const matches = activeTypes.some(t => classes.includes(t));
            p.style.display = matches ? "" : "none";
        });
    }
}

function onFilterBoxClick(element) {
    element.classList.toggle("active");
    applyEventFilters();
}

document.addEventListener("DOMContentLoaded", () => {
    applyEventFilters();
});
