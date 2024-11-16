'use client'

import { useState } from "react";
import Link from "next/link";

export default function Navbar() {
    // State for mobile menu toggle
    const [isMenuOpen, setIsMenuOpen] = useState(false);

    const toggleMenu = () => {
        setIsMenuOpen(!isMenuOpen);
    };

    const signIn = () => {
        // Implement sign-in logic here (e.g., redirect to a sign-in page or handle Auth)
        console.log("Sign-In clicked");
    };

    return (
        <nav className="bg-navbar-backgroundColor shadow-md">
            <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
                <div className="flex justify-between items-center h-16">
                    <Link href="/" className="text-2xl font-bold text-navbar-color">
                        My Gigs
                    </Link>

                    <div className="hidden md:flex space-x-4 ml-8">
                        <Link href="/" className="px-3 py-2 rounded-md text-navbar-color font-medium hover:bg-navbar-accent hover:text-navbar-backgroundColor transition">
                            Home
                        </Link>
                        <Link href="/about" className="px-3 py-2 rounded-md text-navbar-color font-medium hover:bg-navbar-accent hover:text-navbar-backgroundColor transition">
                            About
                        </Link>
                        <Link href="/services" className="px-3 py-2 rounded-md text-navbar-color font-medium hover:bg-navbar-accent hover:text-navbar-backgroundColor transition">
                            Services
                        </Link>
                        <Link href="/contact" className="px-3 py-2 rounded-md text-navbar-color font-medium hover:bg-navbar-accent hover:text-navbar-backgroundColor transition">
                            Contact
                        </Link>
                        <button
                            onClick={signIn}
                            className="px-3 py-2 rounded-md bg-navbar-accent text-navbar-backgroundColor font-medium hover:bg-navbar-backgroundColor hover:text-navbar-color transition"
                        >
                            Sign-In
                        </button>
                    </div>

                    {/* Mobile Toggle Button */}
                    <button
                        onClick={toggleMenu}
                        className="md:hidden text-navbar-color focus:outline-none"
                    >
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            className="h-6 w-6"
                            fill="none"
                            viewBox="0 0 24 24"
                            stroke="currentColor"
                        >
                            <path
                                strokeLinecap="round"
                                strokeLinejoin="round"
                                strokeWidth="2"
                                d="M4 6h16M4 12h16m-7 6h7"
                            />
                        </svg>
                    </button>
                </div>
            </div>

            {/* Mobile Menu */}
            {isMenuOpen && (
                <div className="md:hidden px-4 pt-4 pb-6 space-y-4">
                    <Link href="/" className="block w-full text-center px-4 py-2 rounded-md bg-navbar-backgroundColor text-navbar-color font-medium hover:bg-navbar-accent hover:text-navbar-backgroundColor transition">
                        Home
                    </Link>
                    <Link href="/about" className="block w-full text-center px-4 py-2 rounded-md bg-navbar-backgroundColor text-navbar-color font-medium hover:bg-navbar-accent hover:text-navbar-backgroundColor transition">
                        About
                    </Link>
                    <Link href="/services" className="block w-full text-center px-4 py-2 rounded-md bg-navbar-backgroundColor text-navbar-color font-medium hover:bg-navbar-accent hover:text-navbar-backgroundColor transition">
                        Services
                    </Link>
                    <Link href="/contact" className="block w-full text-center px-4 py-2 rounded-md bg-navbar-backgroundColor text-navbar-color font-medium hover:bg-navbar-accent hover:text-navbar-backgroundColor transition">
                        Contact
                    </Link>
                    <button
                        onClick={signIn}
                        className="block w-full text-center px-4 py-2 rounded-md bg-navbar-accent text-navbar-backgroundColor font-medium hover:bg-navbar-backgroundColor hover:text-navbar-color transition"
                    >
                        Sign-In
                    </button>
                </div>
            )}
        </nav>
    );
}
