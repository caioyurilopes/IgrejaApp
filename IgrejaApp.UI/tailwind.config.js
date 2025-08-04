/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./**/*.razor",
        "./wwwroot/index.html",
        "./**/*.cshtml"
    ],
    theme: {
        extend: {
            animation: {
                'fade-in': 'fadeIn 0.25s ease-out',
                'fade-out': 'fadeOut 0.25s ease-in',
            },
            keyframes: {
                fadeIn: {
                    '0%': {opacity: 0, transform: 'scale(0.95)'},
                    '100%': {opacity: 1, transform: 'scale(1)'},
                },
                fadeOut: {
                    '0%': {opacity: 1, transform: 'scale(1)'},
                    '100%': {opacity: 0, transform: 'scale(0.95)'},
                },
            },
        },
    },
    plugins: []
}