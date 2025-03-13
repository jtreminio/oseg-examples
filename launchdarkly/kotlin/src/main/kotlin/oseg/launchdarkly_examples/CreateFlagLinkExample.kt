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
class CreateFlagLinkExample
{
    fun createFlagLink()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val flagLinkPost = FlagLinkPost(
            key = "flag-link-key-123abc",
            deepLink = "https://example.com/archives/123123123",
            title = "Example link title",
            description = "Example link description",
        )

        try
        {
            val response = FlagLinksBetaApi().createFlagLink(
                projectKey = null,
                featureFlagKey = null,
                flagLinkPost = flagLinkPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling FlagLinksBetaApi#createFlagLink")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling FlagLinksBetaApi#createFlagLink")
            e.printStackTrace()
        }
    }
}
