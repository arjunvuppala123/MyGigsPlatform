'use client';

import { useState } from 'react';
import Link from 'next/link';
import { useUser } from '@auth0/nextjs-auth0/client';
import { IoIosArrowDown } from 'react-icons/io';

const Navbar = () => {
    const [isMenuOpen, setIsMenuOpen] = useState(false);
    const [isDropdownOpen, setIsDropdownOpen] = useState(false);
    const { user } = useUser();

    const toggleMenu = () => setIsMenuOpen(!isMenuOpen);
    const toggleDropdown = () => setIsDropdownOpen(!isDropdownOpen);

    const links = [
        { href: '/', label: 'Home' },
        { href: '/about', label: 'About' },
        { href: '/contact', label: 'Contact' },
    ];

    const gigsLinks = [
        { href: '/gigs/browse', label: 'Browse Gigs' },
        { href: '/gigs/create', label: 'Create Gig' },
        { href: '/gigs/track', label: 'Track Applied Gigs' },
    ];

    return (
        <nav className="bg-navbar-backgroundColor shadow-md">
            <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
                <div className="flex justify-between items-center h-16">
                    {/* Logo */}
                    <Link href="/" className="text-2xl font-bold text-navbar-color">
                        My Gigs
                    </Link>

                    {/* Desktop Menu */}
                    <div className="hidden md:flex space-x-6 items-center">
                        {links.map((link) => (
                            <Link
                                key={link.href}
                                href={link.href}
                                className="px-3 py-2 text-navbar-color font-medium hover:bg-navbar-accent hover:text-navbar-backgroundColor transition rounded-md"
                            >
                                {link.label}
                            </Link>
                        ))}

                        {/* Gigs Dropdown */}
                        <div className="relative">
                            <button
                                onClick={toggleDropdown}
                                className="flex items-center px-3 py-2 text-navbar-color font-medium hover:bg-navbar-accent hover:text-navbar-backgroundColor transition rounded-md"
                            >
                                Gigs
                                <IoIosArrowDown
                                    className={`ml-2 transform transition-transform ${
                                        isDropdownOpen ? 'rotate-180' : ''
                                    }`}
                                />
                            </button>
                            {isDropdownOpen && (
                                <div className="absolute right-0 mt-2 bg-navbar-backgroundColor shadow-lg rounded-md w-48 z-10">
                                    {gigsLinks.map((gigLink) => (
                                        <Link
                                            key={gigLink.href}
                                            href={gigLink.href}
                                            className="block px-4 py-2 text-navbar-color hover:bg-navbar-accent hover:text-navbar-backgroundColor transition"
                                        >
                                            {gigLink.label}
                                        </Link>
                                    ))}
                                </div>
                            )}
                        </div>

                        {/* Auth Links */}
                        {user ? (
                            <Link
                                href="/api/auth/logout"
                                className="px-4 py-2 rounded-md bg-navbar-accent text-navbar-backgroundColor font-medium hover:bg-navbar-backgroundColor hover:text-navbar-color transition"
                            >
                                Sign Out
                            </Link>
                        ) : (
                            <Link
                                href="/api/auth/login"
                                className="px-4 py-2 rounded-md bg-navbar-accent text-navbar-backgroundColor font-medium hover:bg-navbar-backgroundColor hover:text-navbar-color transition"
                            >
                                Sign In
                            </Link>
                        )}
                    </div>

                    {/* Mobile Menu Toggle */}
                    <button
                        onClick={toggleMenu}
                        className="md:hidden text-navbar-color focus:outline-none"
                        aria-expanded={isMenuOpen}
                        aria-label="Toggle menu"
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
                <div className="md:hidden px-4 pt-4 pb-6 space-y-4 bg-navbar-backgroundColor">
                    {links.map((link) => (
                        <Link
                            key={link.href}
                            href={link.href}
                            className="block text-center px-4 py-2 text-navbar-color font-medium hover:bg-navbar-accent hover:text-navbar-backgroundColor transition rounded-md"
                        >
                            {link.label}
                        </Link>
                    ))}

                    {/* Gigs Dropdown in Mobile */}
                    <div className="text-center">
                        <button
                            onClick={toggleDropdown}
                            className="w-full px-4 py-2 text-navbar-color font-medium hover:bg-navbar-accent hover:text-navbar-backgroundColor transition rounded-md flex items-center justify-center"
                        >
                            Gigs
                            <IoIosArrowDown
                                className={`ml-2 transform transition-transform ${
                                    isDropdownOpen ? 'rotate-180' : ''
                                }`}
                            />
                        </button>
                        {isDropdownOpen && (
                            <div className="mt-2 bg-navbar-backgroundColor shadow-lg rounded-md">
                                {gigsLinks.map((gigLink) => (
                                    <Link
                                        key={gigLink.href}
                                        href={gigLink.href}
                                        className="block px-4 py-2 text-navbar-color hover:bg-navbar-accent hover:text-navbar-backgroundColor transition"
                                    >
                                        {gigLink.label}
                                    </Link>
                                ))}
                            </div>
                        )}
                    </div>

                    {/* Auth Links */}
                    {user ? (
                        <Link
                            href="/api/auth/logout"
                            className="block w-full text-center px-4 py-2 bg-navbar-accent text-navbar-backgroundColor font-medium hover:bg-navbar-backgroundColor hover:text-navbar-color transition rounded-md"
                        >
                            Sign Out
                        </Link>
                    ) : (
                        <Link
                            href="/api/auth/login"
                            className="block w-full text-center px-4 py-2 bg-navbar-accent text-navbar-backgroundColor font-medium hover:bg-navbar-backgroundColor hover:text-navbar-color transition rounded-md"
                        >
                            Sign In
                        </Link>
                    )}
                </div>
            )}
        </nav>
    );
};

export default Navbar;