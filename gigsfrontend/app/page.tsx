import Image from "next/image";

export default function Home() {
  return (
      <div className="container-fluid">
        <div className="my-5">
          <section className="bg-gray-50 my-5 py-12">
            <div className="max-w-7xl my-5 mx-auto px-4 sm:px-6 lg:px-8">
              <div className="grid grid-cols-1 md:grid-cols-2 gap-8 items-center">
                {/* Left Section: Text Content */}
                <div className="my-5 space-y-6">
                  <h2 className="text-4xl font-extrabold text-gray-900">
                    Empowering Independent Work with Our Gigs Platform
                  </h2>
                  <p className="text-lg text-gray-700">
                    In a rapidly changing economy, gig platforms provide freelancers with opportunities to connect with
                    businesses, offering skills across various domains. Whether you're a designer, developer, or
                    consultant, the gig economy allows you to thrive on your own terms.
                  </p>
                  <p className="text-lg text-gray-700">
                    Our platform bridges the gap between talented individuals and businesses in need of specialized
                    services, making it easy to collaborate, grow, and succeed. By fostering flexible work arrangements,
                    we&#39;re shaping the future of work.
                  </p>
                  <a
                      href="/register"
                      className="inline-block px-6 py-3 bg-navbar-backgroundColor text-white font-medium rounded-md shadow-md hover:bg-navbar-accent hover:text-navbar-backgroundColor hover:border-2 hover:border-navbar-backgroundColor transition"
                  >
                    Get Started
                  </a>
                </div>

                {/* Right Section: Image */}
                <div className="my-4">
                  <Image
                      src="https://designtemplate.tech/Working-from-Home-Male-Freelancer-2D-Cartoon-Character-Illustration-700.webp"
                      alt="Freelancer working on a laptop"
                      width={700} // specify width and height for optimization
                      height={700} // specify height for optimization
                      className="w-full h-auto rounded-md shadow-md"
                  />
                </div>
              </div>
            </div>
          </section>
        </div>
      </div>
  );
}
