package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class PostExtinctionExample
{
    fun postExtinction()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val extinction1 = Extinction(
            revision = "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3",
            message = "Remove flag for launched feature",
            time = 1706701522000,
            flagKey = "enable-feature",
            projKey = "default",
        )

        val extinction = arrayListOf<Extinction>(
            extinction1,
        )

        try
        {
            CodeReferencesApi().postExtinction(
                repo = null,
                branch = null,
                extinction = extinction,
            )
        } catch (e: ClientException) {
            println("4xx response calling CodeReferencesApi#postExtinction")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling CodeReferencesApi#postExtinction")
            e.printStackTrace()
        }
    }
}
