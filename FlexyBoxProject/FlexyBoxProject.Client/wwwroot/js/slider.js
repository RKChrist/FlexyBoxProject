window.initSlider = (sliderEl, autoInterval) => {
    const slider = sliderEl;
    const slides = Array.from(slider.children);
    const gap = parseInt(getComputedStyle(slider).gap) || 0;
    let current = 0;

    function scrollToCurrent() {
        const target = slides[current];
        const left = target.offsetLeft - gap;
        slider.scrollTo({ left, behavior: 'smooth' });
    }

    function next() {
        current = (current + 1) % slides.length;
        scrollToCurrent();
    }
    function prev() {
        current = (current - 1 + slides.length) % slides.length;
        scrollToCurrent();
    }

    // Auto-rotate
    let timer = setInterval(next, autoInterval);

    // Pause on hover
    slider.addEventListener('mouseenter', () => clearInterval(timer));
    slider.addEventListener('mouseleave', () => timer = setInterval(next, autoInterval));

    // Keyboard nav
    slider.addEventListener('keydown', e => {
        if (e.key === 'ArrowLeft') prev();
        if (e.key === 'ArrowRight') next();
    });

    // Focusable
    slider.tabIndex = 0;
};
