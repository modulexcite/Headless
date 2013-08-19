﻿namespace Headless
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using Headless.Activation;

    /// <summary>
    ///     The <see cref="BrowserExtensions" />
    ///     class is used to provide extension methods to the <see cref="IBrowser" /> interface.
    /// </summary>
    public static class BrowserExtensions
    {
        /// <summary>
        /// Browses to the specified location.
        /// </summary>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <param name="location">
        /// The specific location to request rather than that identified by the page.
        /// </param>
        /// <returns>
        /// An <see cref="IPage"/> value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="browser"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="location"/> parameter is <c>null</c>.
        /// </exception>
        public static dynamic GoTo(this IBrowser browser, Uri location)
        {
            return browser.GoTo(location, HttpStatusCode.OK);
        }

        /// <summary>
        /// Browses to the specified location.
        /// </summary>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <param name="location">
        /// The specific location to request rather than that identified by the page.
        /// </param>
        /// <param name="expectedStatusCode">
        /// The expected status code.
        /// </param>
        /// <returns>
        /// An <see cref="IPage"/> value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="browser"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="location"/> parameter is <c>null</c>.
        /// </exception>
        public static dynamic GoTo(this IBrowser browser, Uri location, HttpStatusCode expectedStatusCode)
        {
            if (browser == null)
            {
                throw new ArgumentNullException("browser");
            }

            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            var pageFactory = new DefaultPageFactory();

            var dynamicPage = browser.GoTo<DynamicResolverPage>(location, expectedStatusCode, pageFactory);

            return dynamicPage.ResolvedPage;
        }

        /// <summary>
        /// Browses to the location defined by the specified page type.
        /// </summary>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <typeparam name="T">
        /// The type of page to return.
        /// </typeparam>
        /// <returns>
        /// A <typeparamref name="T"/> value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="browser"/> parameter is <c>null</c>.
        /// </exception>
        public static T GoTo<T>(this IBrowser browser) where T : Page, new()
        {
            var page = new T();

            return browser.GoTo<T>(page.Location, HttpStatusCode.OK);
        }

        /// <summary>
        /// Browses to the location defined by the specified page type and validates the status code.
        /// </summary>
        /// <typeparam name="T">
        /// The type of page to return.
        /// </typeparam>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <param name="expectedStatusCode">
        /// The expected status code.
        /// </param>
        /// <returns>
        /// A <typeparamref name="T"/> value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="browser"/> parameter is <c>null</c>.
        /// </exception>
        public static T GoTo<T>(this IBrowser browser, HttpStatusCode expectedStatusCode) where T : IPage, new()
        {
            var page = new T();

            return browser.GoTo<T>(page.Location, expectedStatusCode);
        }

        /// <summary>
        /// Browses to the specified location.
        /// </summary>
        /// <typeparam name="T">
        /// The type of page to return.
        /// </typeparam>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <param name="location">
        /// The specific location to request rather than that identified by the page.
        /// </param>
        /// <returns>
        /// A <see cref="Page"/> value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="browser"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="location"/> parameter is <c>null</c>.
        /// </exception>
        public static T GoTo<T>(this IBrowser browser, Uri location) where T : IPage, new()
        {
            return browser.GoTo<T>(location, HttpStatusCode.OK);
        }

        /// <summary>
        /// Browses to the specified location and validates the status code.
        /// </summary>
        /// <typeparam name="T">
        /// The type of page to return.
        /// </typeparam>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <param name="expectedStatusCode">
        /// The expected status code.
        /// </param>
        /// <returns>
        /// A <typeparamref name="T"/> value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="browser"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="location"/> parameter is <c>null</c>.
        /// </exception>
        public static T GoTo<T>(this IBrowser browser, Uri location, HttpStatusCode expectedStatusCode)
            where T : IPage, new()
        {
            if (browser == null)
            {
                throw new ArgumentNullException("browser");
            }

            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            var pageFactory = new DefaultPageFactory();

            return browser.GoTo<T>(location, expectedStatusCode, pageFactory);
        }

        /// <summary>
        /// Browses to the specified location and validates the status code.
        /// </summary>
        /// <typeparam name="T">
        /// The type of page to return.
        /// </typeparam>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <param name="expectedStatusCode">
        /// The expected status code.
        /// </param>
        /// <param name="pageFactory">
        /// The page factory.
        /// </param>
        /// <returns>
        /// A <see cref="IPage"/> value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="browser"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="location"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="pageFactory"/> parameter is <c>null</c>.
        /// </exception>
        public static T GoTo<T>(
            this IBrowser browser, 
            Uri location, 
            HttpStatusCode expectedStatusCode, 
            IPageFactory pageFactory) where T : IPage, new()
        {
            if (browser == null)
            {
                throw new ArgumentNullException("browser");
            }

            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            if (pageFactory == null)
            {
                throw new ArgumentNullException("pageFactory");
            }

            using (var request = new HttpRequestMessage(HttpMethod.Get, location))
            {
                return browser.Execute<T>(request, expectedStatusCode, pageFactory);
            }
        }

        /// <summary>
        /// Posts the parameters to the specified location.
        /// </summary>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <param name="parameters">
        /// The POST parameters.
        /// </param>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <returns>
        /// An <see cref="IPage"/> value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="browser"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="parameters"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="location"/> parameter is <c>null</c>.
        /// </exception>
        public static dynamic PostTo(this IBrowser browser, IDictionary<string, string> parameters, Uri location)
        {
            return browser.PostTo(parameters, location, HttpStatusCode.OK);
        }

        /// <summary>
        /// Posts the parameters to the specified location.
        /// </summary>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <param name="parameters">
        /// The POST parameters.
        /// </param>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <param name="expectedStatusCode">
        /// The expected status code.
        /// </param>
        /// <returns>
        /// An <see cref="IPage"/> value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="browser"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="parameters"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="location"/> parameter is <c>null</c>.
        /// </exception>
        public static dynamic PostTo(
            this IBrowser browser, 
            IDictionary<string, string> parameters, 
            Uri location, 
            HttpStatusCode expectedStatusCode)
        {
            if (browser == null)
            {
                throw new ArgumentNullException("browser");
            }

            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            var pageFactory = new DefaultPageFactory();

            var dynamicPage = browser.PostTo<DynamicResolverPage>(parameters, location, expectedStatusCode, pageFactory);

            return dynamicPage.ResolvedPage;
        }

        /// <summary>
        /// Posts the parameters to the location defined by the specified page type.
        /// </summary>
        /// <typeparam name="T">
        /// The type of page to return.
        /// </typeparam>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <param name="parameters">
        /// The POST parameters.
        /// </param>
        /// <returns>
        /// A <typeparamref name="T"/> value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="browser"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="parameters"/> parameter is <c>null</c>.
        /// </exception>
        public static T PostTo<T>(this IBrowser browser, IDictionary<string, string> parameters) where T : IPage, new()
        {
            var page = new T();

            return browser.PostTo<T>(parameters, page.Location, HttpStatusCode.OK);
        }

        /// <summary>
        /// Posts the parameters to the specified location.
        /// </summary>
        /// <typeparam name="T">
        /// The type of page to return.
        /// </typeparam>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <param name="parameters">
        /// The POST parameters.
        /// </param>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <returns>
        /// A <typeparamref name="T"/> value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="browser"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="parameters"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="location"/> parameter is <c>null</c>.
        /// </exception>
        public static T PostTo<T>(this IBrowser browser, IDictionary<string, string> parameters, Uri location)
            where T : IPage, new()
        {
            return browser.PostTo<T>(parameters, location, HttpStatusCode.OK);
        }

        /// <summary>
        /// Posts the parameters to the specified location and validates the status code.
        /// </summary>
        /// <typeparam name="T">
        /// The type of page to return.
        /// </typeparam>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <param name="parameters">
        /// The POST parameters.
        /// </param>
        /// <param name="expectedStatusCode">
        /// The expected status code.
        /// </param>
        /// <returns>
        /// A <typeparamref name="T"/> value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="browser"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="parameters"/> parameter is <c>null</c>.
        /// </exception>
        public static T PostTo<T>(
            this IBrowser browser, 
            IDictionary<string, string> parameters, 
            HttpStatusCode expectedStatusCode) where T : IPage, new()
        {
            var page = new T();

            return browser.PostTo<T>(parameters, page.Location, expectedStatusCode);
        }

        /// <summary>
        /// Posts the parameters to the specified location and validates the status code.
        /// </summary>
        /// <typeparam name="T">
        /// The type of page to return.
        /// </typeparam>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <param name="parameters">
        /// The POST parameters.
        /// </param>
        /// <param name="location">
        /// The location to post to.
        /// </param>
        /// <param name="expectedStatusCode">
        /// The expected status code.
        /// </param>
        /// <returns>
        /// A <typeparamref name="T"/> value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="browser"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="parameters"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="location"/> parameter is <c>null</c>.
        /// </exception>
        public static T PostTo<T>(
            this IBrowser browser, 
            IDictionary<string, string> parameters, 
            Uri location, 
            HttpStatusCode expectedStatusCode) where T : IPage, new()
        {
            if (browser == null)
            {
                throw new ArgumentNullException("browser");
            }

            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            var pageFactory = new DefaultPageFactory();

            return browser.PostTo<T>(parameters, location, expectedStatusCode, pageFactory);
        }

        /// <summary>
        /// Posts the parameters to the specified location and validates the status code.
        /// </summary>
        /// <typeparam name="T">
        /// The type of page to return.
        /// </typeparam>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <param name="parameters">
        /// The post parameters.
        /// </param>
        /// <param name="location">
        /// The location to post to.
        /// </param>
        /// <param name="expectedStatusCode">
        /// The expected status code.
        /// </param>
        /// <param name="pageFactory">
        /// The page factory.
        /// </param>
        /// <returns>
        /// A <typeparamref name="T"/> value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="browser"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="parameters"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="location"/> parameter is <c>null</c>.
        /// </exception>
        public static T PostTo<T>(
            this IBrowser browser, 
            IDictionary<string, string> parameters, 
            Uri location, 
            HttpStatusCode expectedStatusCode, 
            IPageFactory pageFactory) where T : IPage, new()
        {
            if (browser == null)
            {
                throw new ArgumentNullException("browser");
            }

            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            using (var formData = new FormUrlEncodedContent(parameters))
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, location))
                {
                    request.Content = formData;

                    return browser.Execute<T>(request, expectedStatusCode, pageFactory);
                }
            }
        }
    }
}