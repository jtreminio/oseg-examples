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
class CreateOAuth2ClientExample
{
    fun createOAuth2Client()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val oauthClientPost = OauthClientPost(
            name = null,
            redirectUri = null,
            description = null,
        )

        try
        {
            val response = OAuth2ClientsApi().createOAuth2Client(
                oauthClientPost = oauthClientPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling OAuth2ClientsApi#createOAuth2Client")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling OAuth2ClientsApi#createOAuth2Client")
            e.printStackTrace()
        }
    }
}
