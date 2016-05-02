using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

namespace ForcesOfCorruptionModdingTool
{
    public static class Test
    {
        /// <summary>
        /// Attempts to retrieve the real cause of a composition failure.
        /// </summary>
        /// <remarks>
        /// Sometimes a MEF composition fails because an exception occurs in the ctor of a type we're trying to
        /// create. Unfortunately, the CompositionException doesn't make that easily available, so we don't get
        /// that info in haystack. This method tries to find that exception as that's really the only one we care
        /// about if it exists. If it can't find it, it returns the original composition exception.
        /// </remarks>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Exception UnwrapCompositionException(this Exception exception)
        {
            var compositionException = exception as CompositionException;
            if (compositionException == null)
            {
                return exception;
            }

            var unwrapped = compositionException;
            while (unwrapped != null)
            {
                var firstError = unwrapped.Errors.FirstOrDefault();
                var currentException = firstError?.Exception;

                if (currentException == null)
                    break;

                var composablePartException = currentException as ComposablePartException;

                if (composablePartException?.InnerException != null)
                {
                    var innerCompositionException = composablePartException.InnerException as CompositionException;
                    if (innerCompositionException == null)
                    {
                        return currentException.InnerException ?? exception;
                    }
                    currentException = innerCompositionException;
                }

                unwrapped = currentException as CompositionException;
            }

            return exception; // Fuck it, couldn't find the real deal. Throw the original.
        }
    }
}
